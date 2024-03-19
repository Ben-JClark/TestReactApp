import { useEffect, useState } from 'react';
import './App.css';

interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface Shop {
    totalSales: number;
    totalRevenue: number;
}

function App() {
    const [forecasts, setForecasts] = useState<Forecast[]>();
    const [shop, setShop] = useState<Shop | null>(null);

    useEffect(() => {
        try {
            populateWeatherData();
            populateShopData();
        } catch (error) {
            console.log("Error fetching the data: ", error);
        }
    }, []);

    const contents = forecasts === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <>
            <div>
                <h1 id="tabelLabel">Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
            <div>
                <h1 id="shopLabel">Shop Shulker Sales</h1>
                {
                    shop === null ? (<><p>Loading Shop Data...</p><button onClick={populateShopData}>Reload</button></>) :
                    (<p>{`A total of ${shop?.totalSales} Shulker shells have been sold, generating ${shop?.totalRevenue} Diamonds`}</p>)
                }
            </div>
        </>
    );

    async function populateWeatherData() {
        const response = await fetch('weatherforecast/short');
        const data = await response.json();
        setForecasts(data);
    }
    async function populateShopData() {
        const response = await fetch("https://localhost:7146/shop");
        console.log("response from shop ", response);
        const data = await response.json();
        setShop(data);
    }
}

export default App;