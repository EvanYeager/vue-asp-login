<script setup lang="ts">
import LoginService from '@/services/LoginService.vue';

const loginService = new LoginService();
const username: string = "";
const password: string = "";

let failure: boolean = false;

const login = (username: string, password: string) => {
    loginService.login(username, password).then((success) => {
        if (success) {
            console.log("Login successful");
            window.location.href = "/";
        } else {
            failure = true;
        }
    });

}

</script>

<template>
    <p>Log in to use this application</p>
    <input type="text" v-model="username" placeholder="Username">
    <input type="password" v-model="password" @keyup.enter="login(username, password)" placeholder="Password">
    <button @click="login(username, password)">Log in</button>
    <p v-if="failure">Login failed</p>

    <p id="note">Hint: admin admin is a valid login.</p>
</template>

<style>
#note {
    margin-top: 100px;
}
</style>