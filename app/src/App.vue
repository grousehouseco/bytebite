<script setup>
  import { RouterView, useRouter } from 'vue-router'
  import { useAuth0 } from '@auth0/auth0-vue';
  import { watch, inject, ref } from 'vue';
  const { isAuthenticated, loginWithRedirect, user } = useAuth0()
  const userService = inject('userService')
  const router = useRouter()

  const userId = ref('')
  watch(isAuthenticated, (cur)=>{
    if(!cur){
      loginWithRedirect()
    }
  })
  watch(user, (newUser) => {
    if (newUser && userService) {
      userService.getUser(newUser.email).then(res => {
        userId.value = res[0].id
        router.push(`/${res[0].id}`)
      })
    } else {
      // User has logged out
      router.push('/login')
    }
  });
</script>

<template>
  <RouterView />
</template>