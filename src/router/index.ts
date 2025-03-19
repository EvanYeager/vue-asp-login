import { createRouter, createWebHistory } from 'vue-router'
// @ts-ignore
import MainPage from '@/components/MainPage.vue'
import LoginPage from '@/components/LoginPage.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: MainPage,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/login',
      name: 'login',
      component: LoginPage,
    }
  ],
})

export default router
