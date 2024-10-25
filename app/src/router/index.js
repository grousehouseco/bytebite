import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/bytebite-home.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'ByteBite',
      component: HomeView
    },
    {
      path: '/digitalpantry',
      name: 'Digital Pantry',
      component: () => import('../views/digital-pantry.vue'),
      children: [
        {
          path: '/add-groceries'
        }
      ]
    },
    {
      path: '/reciperecon',
      name: 'Recipe Recon',
      component: () => import('../views/recipe-recon.vue')
    }
  ]
})

export default router
