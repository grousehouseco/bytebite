<script setup>
  import { RouterView } from 'vue-router'
  import TitleBar from './components/nav/title-bar.vue';
  import LeftNav from './components/nav/left-nav.vue';
</script>

<template>
  <div class="w-full h-screen flex flex-row bg-base-200">
    <LeftNav/>
    <div class="w-full h-screen flex pb-8 pr-8 flex-col">
      <TitleBar />
      <div class="card size-full bg-base-100 shadow-md">
        <RouterView class="card-body"/>
      </div>
    </div>
  </div>
</template>