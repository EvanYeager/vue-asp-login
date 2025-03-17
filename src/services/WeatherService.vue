<script lang="ts">
import WeatherModel from '@/models/WeatherModel.vue';
import axios from 'axios';

export default class WeatherService {

    private aspUrl = "https://localhost:7007";

    constructor() {}
    
    async ping() {
        const response = await axios.get("https://api.weather.gov/points/39.7456,-97.0892")
        console.log(response);
        console.log(response.data.properties.forecast);
    }

    async getWeatherForecast(location: string): Promise<WeatherModel | undefined> {
        // get coords for location
        const coords = await this.getCoords(location);
        if (!coords)
            return undefined;

        const x = coords.y; // i have no clue why the coords need to be swapped like this
        const y = coords.x;

        // get weather data from weather.gov
        const response = await axios.get(`https://api.weather.gov/points/${x},${y}`);
        const forecastUrl: string = response.data.properties.forecast;
        const forecast = await axios.get(forecastUrl);

        const weatherPeriod = forecast.data.properties.periods[0];
        const out = new WeatherModel(weatherPeriod.name, weatherPeriod.isDaytime, weatherPeriod.temperature, weatherPeriod.temperatureUnit, weatherPeriod.shortForecast);

        return out;
    }

    async getCoords(location: string) {
        try {
            const address = encodeURIComponent(location);
            const url = `${this.aspUrl}/api/geocoding?address=${address}`;
            const response = await axios.get(url, { headers: { 'Access-Control-Allow-Origin': '*' } });
            return response.data.result.addressMatches[0].coordinates;
        }
        catch (error) {
            console.error("Unable to find coordinates in WeatherService.vue. Error message: " + error);
            return null;
        }
        
    }
}
</script>
