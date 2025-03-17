<script setup lang="ts">
import WeatherModel from '@/models/WeatherModel.vue';
import LocationService from '@/services/LocationService.vue';
import WeatherService from '@/services/WeatherService.vue';
import { ref } from 'vue';

const locationService: LocationService = LocationService.getInstance();
const activeLocation = locationService.getActiveLocation;
const weatherService = new WeatherService;

let forecast = ref();

if (activeLocation.value) {
  weatherService.getWeatherForecast(activeLocation.value)
    .then(result => {
      forecast.value = result;
    })
    .catch(error => {
      console.error('Error fetching forecast:', error);
    });
    }
  </script>

  <template>
    <h1 v-if="activeLocation !== null">Weather for {{ activeLocation }}</h1>
    <div v-if="forecast" id="weather-container">
      <div class="text-container">
        <h3>{{ forecast.name }}</h3>
        <p>{{ forecast.forecastDescription }}</p>
        <p v-if="forecast.isDaytime">High of <strong>{{ forecast.temperature + " " + forecast.temperatureUnit }}</strong></p>
        <p v-else>Low of <strong>{{ forecast.temperature + " " + forecast.temperatureUnit }}</strong></p>
      </div>
      <img class="image" v-if="forecast.isDaytime" src="../assets/sun.svg">
      <img class="image" v-else src="../assets/moon.svg">
    </div>
  </template>

  <style>
    .image {
      width: 150px;
      margin-left: 100px;
    }

    #weather-container {
      display: flex;
      align-items: center;
    }

    .text-container {
      display: flex;
      flex-direction: column;
    }

    #weather-container p {
      font-size: 19px;
      width: fit-content;
    }

    #weather-container h3 {
      font-size: 24px;
      margin: 20px;
      font-weight: bold;
    }
  </style>