<script setup>
  import * as svg from '../../assets/svg-strings.js'
  import PantryModule from './pantry-module.vue';
  const modules = [
    { icon: svg.broccoli, title:'Produce', content:{} },
    { icon: svg.fish, title:'Fish & Seafood', content:{} },
    { icon: svg.meat, title:'Meat & Poultry', content:{} },
    { icon: svg.cheese, title:'Dairy', content:{} },
    { icon: svg.jar, title:'Packaged Goods', content:{} },
    { icon: svg.spice, title:'Herbs & Spices', content:{} },
    { icon: svg.whisk, title:'Dry Goods', content:{} },
    { icon: svg.basket, title:'Miscellaneous', content:{} }
  ]
</script>
<template>
  <PantryModule class="overflow-scroll" :modules="modules"/>
</template>