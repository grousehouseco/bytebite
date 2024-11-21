<script setup>
    import { inject } from 'vue';
    const routeHelper = inject('routeHelper')
    const props = defineProps(['userId'])
    import { ref } from 'vue'
    import * as routeConstants from '../../router/route-constants'
    let openButtonId = ref(-1)
    function menuItemClick(id, parentId = -1){
        if(parentId === -1){
            openButtonId.value = id === openButtonId.value ? -1 : id
        }
    }
    function getRoute(pathParts){
        return routeHelper.formatUrl(pathParts).replace(routeConstants.BASE, props.userId)
    }
</script>
<template>
    <div class="flex flex-col">
        <ul class="menu menu-sm bg-base-200 w-fit max-w-sm text-md">
            <li v-for="item in routeConstants.leftNavItems" :key="item.id">
                <RouterLink :to= getRoute(item.path) exact-active-class="active" @click="menuItemClick(item.id)">
                    <span class="material-symbols-rounded mx-auto">{{ item.icon }}</span>
                    <p class="font-bold text-lg">{{ item.text }}</p>
                </RouterLink>
                <ul v-if="openButtonId === item.id">
                    <li v-for="child in item.children" :key="child.id">
                        <RouterLink :to=getRoute(child.path) exact-active-class="active" @click="menuItemClick(child.id, item.id)">
                            <span class="material-symbols-rounded mx-auto">{{ child.icon }}</span>
                            <p class="text-lg">{{ child.text }}</p>
                        </RouterLink>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</template>
<style>
.filled {
    font-variation-settings:'FILL' 100
}
</style>