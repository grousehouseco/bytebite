import { createRouter, createWebHistory } from 'vue-router'
import UserProfile from '@/components/user/user-profile.vue'
import UserSettings from '@/components/user/user-settings.vue'
import * as rh from './route-constants'
import LoginView from '@/views/login-view.vue'
import Dashboard from '@/components/dashboard/dashboard.vue'
import Recipes from '@/components/recipes/recipes.vue'
import Pantry from '@/components/pantry/pantry.vue'
import MainView from '@/views/main-view.vue'
import ManagePantry from '@/components/pantry/manage-pantry.vue'
import Cook from '@/components/cook/cook.vue'
import Household from '@/components/household/household.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', redirect: 'login'},
    { path: '/'+rh.LOGIN, name: 'login', component: LoginView},
    { path: '/'+rh.PROFILE, component: MainView, props: true, children: [
      { path:'', component: UserProfile },
      { path: rh.SETTINGS, props: true,component: UserSettings },
      { path: rh.HOME, props: true, component: Dashboard },
      { path: rh.PANTRY, props: true, component: Pantry, children: [
        { path: rh.PANTRY_MANAGE, props: true, component: ManagePantry}
      ] },
      { path: rh.RECIPES, props: true, component: Recipes },
      { path: rh.COOK, props: true, component: Cook },
      { path: rh.HOUSEHOLD, props: true, component: Household },
    ]}
  ]
})

export default router
