<script lang="ts">

export interface Iforecast {
    name: string;
    isDaytime: boolean;
    temperature: number;
    temperatureUnit: string;
    forecastDescription: string;
}

export default class implements Iforecast {

    name: string;
    isDaytime: boolean;
    temperature: number;
    temperatureUnit: string;
    forecastDescription: string;

    constructor(name: string,
        isDaytime: boolean,
        temperature: number,
        temperatureUnit: string,
        forecastDescription: string) {
            this.name = name;
            this.isDaytime = isDaytime;
            this.temperature = temperature;
            this.temperatureUnit = temperatureUnit;
            this.forecastDescription = forecastDescription;
        }
}

</script>