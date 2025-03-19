<script setup>
import LocationsView from '@/views/LocationsView.vue';
import WeatherView from '@/views/WeatherView.vue';
</script>

<template>
    <div class="container">
        <div id="left">
            <LocationsView></LocationsView>
        </div>
        <div id="right">
            <WeatherView></WeatherView>
        </div>
    </div>
</template>

<style scoped>
.container {
    display: grid;
    grid-template-columns: 1fr 1fr;
    width: 100%;
}

#left {
    line-height: 1.5;
    flex-direction: column;
}

#right {
    flex-grow: 1;
}

.logo {
    display: block;
    margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
    #left {
        display: flex;
        place-items: center;
        padding-right: calc(var(--section-gap));
    }
}
</style>
