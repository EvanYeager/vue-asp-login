import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import VueCookies from 'vue-cookies'
import LoginService from './services/LoginService.vue'

const app = createApp(App)

app.use(router)

app.use(VueCookies, {expires: '5h'});

app.mount('#app')

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
        // check if logged in
        const login: LoginService = new LoginService();
        if (!login.isLoggedIn()) {
            next({name: 'login'});
        }
        else
            next();
    }
    else
        next();
})

