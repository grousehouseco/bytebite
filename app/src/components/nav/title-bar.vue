<script setup>
  import { useRoute } from 'vue-router'
  const route = useRoute()
</script>
<template>
  <div class="navbar bg-base-200 gap-1">
    <div class="ml-2 dropdown dropdown-start">
      <div class="flex-none">
        <button class="btn btn-ghost btn-circle" role="button">
          <span class="material-symbols-rounded">menu</span>
        </button>
        <ul class="menu bg-base-200 rounded-box w-56 dropdown-content mt-2">
          <li><RouterLink to="/">Home</RouterLink></li>
          <li><RouterLink to="/digitalpantry">Digital Pantry</RouterLink></li>
          <li><RouterLink to="/reciperecon">Recipe Recon</RouterLink></li>
        </ul>
      </div>
    </div>
    
    <div class="flex-1">
      <h1 class="prose prose-xl">{{ route.name }}</h1>
    </div>
    <div class="flex-none">
      <button class="btn btn-square btn-ghost">
        <span class="material-symbols-rounded">more_vert</span>
      </button>
    </div>
  </div>
</template>