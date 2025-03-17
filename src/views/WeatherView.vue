<script setup lang="ts">
import eventBus from '@/eventBus';
import LocationService from '@/services/LocationService.vue';
import WeatherService from '@/services/WeatherService.vue';
import { onMounted, onUnmounted, ref } from 'vue';

const locationService: LocationService = LocationService.getInstance();
const activeLocation = locationService.getActiveLocation;
const weatherService = new WeatherService;

let forecast = ref();

const getWeather = () => {
  console.log('Getting weather for', activeLocation.value);
  weatherService.getWeatherForecast(activeLocation.value!)
  .then(result => {
    forecast.value = result;
  })
  .catch(error => {
    console.error('Error fetching forecast:', error);
  });
}

if (activeLocation.value) {
  getWeather();
}


onMounted(() => {
  eventBus.on('locationUpdated', getWeather);
});

onUnmounted(() => {
  eventBus.off('locationUpdated', getWeather);
})

</script>

  <template>
    <h1 v-if="activeLocation !== null">Weather for {{ activeLocation }}</h1>
    <div v-if="forecast && forecast.name" id="weather-container">
      <div class="text-container">
        <h3>{{ forecast.name }}</h3>
        <p>{{ forecast.forecastDescription }}</p>
        <p v-if="forecast.isDaytime">High of <strong>{{ forecast.temperature + " " + forecast.temperatureUnit }}</strong></p>
        <p v-else>Low of <strong>{{ forecast.temperature + " " + forecast.temperatureUnit }}</strong></p>
      </div>
      <img class="image" v-if="forecast.isDaytime" src="../assets/sun.svg">
      <img class="image" v-else src="../assets/moon.svg">
    </div>
    <h3 v-else>Weather data could not be found for this location. Make sure the format is [street address], [city], [state].</h3>
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