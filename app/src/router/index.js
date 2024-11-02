import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/bytebite-home.vue'
import DigitalPantry from '@/views/digital-pantry.vue'
import Inventory from '@/components/inventory.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', name: 'home', component: HomeView },
    { path: '/pantry', name: 'pantry', component: DigitalPantry, children: [
      { path: '', component: DigitalPantry },
      { path: 'add-groceries', name: 'addGroceries', component: Inventory},
      { path: 'remove-groceries', name: 'removeGroceries', component: Inventory},
    ]},
    { path: '/reciperecon', name: 'recipeRecon', component: () => import('../views/recipe-recon.vue') },
    { path: '/cook', name: 'cook', component: HomeView },
    { path: '/household', name: 'household', component: HomeView }
  ]
})

export default router
