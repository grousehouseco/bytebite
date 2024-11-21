<script setup>
  import { useAuth0 } from '@auth0/auth0-vue';
  import { useRouter } from 'vue-router';
  import Breadcrumbs from './breadcrumbs.vue';
  const { logout, user } = useAuth0();
  const props = defineProps(['userId'])
  //import * as str from '../../router/route-constants'
  const baseUrl = `/${props.userId}`
  const settingsUrl = `${baseUrl}/settings`
  const router = useRouter()
  function doLogout(){
    logout({ logoutParams: { returnTo: window.location.origin } })
  }
</script>
<template>
  <div class="navbar bg-base-200 gap-1 h-24">
    <div class="size-12 p-2 mx-12 rounded-full border border-solid border-primary-content bg-primary hover:border-accent-content hover:bg-accent">
        <img src="../../assets/chef.svg" class="size-full mx-auto"/>
    </div>
    <Breadcrumbs :path="router.fullPath"/>
    <div class="grow"></div>
    <div class="dropdown dropdown-end">
      <div class="avatar">
        <div class=" shadow-md w-12 rounded-full border border-solid border-base-200 hover:border-neutral" role="button" tabindex="0">
          <img :src="user?.picture" />
        </div>
      </div>
      <ul class="menu dropdown-content bg-base-100 rounded-box z-[1] w-52 p-2 shadow">
        <li>
          <RouterLink :to=settingsUrl>
              <span class="material-symbols-rounded mx-auto">settings</span>
              <p class="text-md">Settings</p>
          </RouterLink>
        </li>
        <li>
          <button @click="doLogout()">
              <span class="material-symbols-rounded mx-auto">logout</span>
              <p class="text-md">Log Out</p>
          </button>
        </li>
      </ul>
    </div>
  </div>
</template>