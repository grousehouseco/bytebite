<script setup>
  import { inject, watch } from 'vue';
  import { useAuth0 } from '@auth0/auth0-vue';
  import { useRouter } from 'vue-router';
  const { loginWithRedirect, isAuthenticated } = useAuth0()
  const userService = inject('userService');
  const router = useRouter()

  watch(isAuthenticated, (cur)=>{
    if(cur && userService && userService.userId){
      router.push(`${userService.userId}`)
    }
  })

  function login(){
    loginWithRedirect();
  }
</script>
<template>
  <div class="hero bg-base-200 min-h-screen">
    <div class="hero-content text-center">
      <div class="max-w-lg">
        <div class="mx-auto size-24 p-2 rounded-full mb-6">
          <img src="../assets/chef.svg" class="size-full mx-auto"/>
        </div>
        <div class="rounded-xl shadow-inner bg-base-100 flex flex-row mb-8 group">

          <div class="transition ease-in-out rounded-xl text-5xl font-tourney text-primary bg-neutral p-2 group-hover:text-neutral group-hover:bg-base-100">BYTE</div>
          <div class="transition ease-in-out rounded-xl text-5xl font-bungee p-2 group-hover:text-accent group-hover:bg-neutral">BITE</div>
        </div>
        <button class="btn btn-primary font-bungee hover:text-primary hover:bg-neutral" @click="login()">Login</button>
      </div>
    </div>
  </div>
</template>