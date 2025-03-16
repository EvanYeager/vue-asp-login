<script setup lang="ts">
import axios from 'axios';
import LocationService from '@/services/LocationService.vue';
import { computed } from 'vue';

const locationService: LocationService = LocationService.getInstance();
const activeLocation = computed(() => locationService.getActiveLocation);

</script>

<template>
    <h1 v-if="activeLocation.value !== null">Weather for {{ activeLocation }}</h1>

</template>