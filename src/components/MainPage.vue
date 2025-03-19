<script setup>
import LocationsView from '@/views/LocationsView.vue';
import WeatherView from '@/views/WeatherView.vue';
import LoginService from '@/services/LoginService.vue';

const loginService = new LoginService();

const logout = () => {
  window.location.href = "/login";
  loginService.logout();
}

</script>

<template>
    <button id="logout" @click="logout">Logout</button>
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

#logout {
    float: right;
    margin-top: -100px;
    margin-right: -50px;
    padding: 10px 20px;
    border-radius: 10px;
    border: 1px solid rgba(255, 0, 0, 0.267);
    color: rgba(255, 0, 0, 0.747);
}

#left {
    line-height: 1.5;
    flex-direction: column;
}

#right {
    min-width: 500px;
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
