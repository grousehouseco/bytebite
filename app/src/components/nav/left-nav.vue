<script setup>
    import { ref } from 'vue'
    const menuItems = ref([
        {id: "0", tooltip: "Home", icon: "home", href: 'home', text: ""},
        {id: "1", tooltip: "Pantry", icon: "kitchen", href: 'pantry', text: "", children: [
            {id: "5", icon: "add", text: "Add", href: 'addGroceries'},
            {id: "6", icon: "remove", text: "Remove", href: 'removeGroceries'}
        ]},
        {id: "2", tooltip: "Recipes", icon: "menu_book", href: 'recipeRecon', text: ""},
        {id: "3", tooltip: "Cook", icon: "skillet", href: 'cook', text: ""},
        {id: "4", tooltip: "Household", icon: "diversity_4", href: 'household', text: ""}
    ])
    let openButtonId = ref(-1)
    function menuItemClick(id, parentId = -1){
        if(parentId === -1){
            openButtonId.value = id === openButtonId.value ? -1 : id
        }
    }
</script>
<template>
    <div class="flex flex-col">
        <div class="size-24 mx-auto mt-4">
            <div class="size-20 p-3 mx-auto rounded-full border border-solid border-primary-content bg-primary hover:border-accent-content hover:bg-accent">
                <img src="../../assets/chef.svg" class="size-full mx-auto"/>
            </div>
        </div>
        <ul class="menu menu-sm bg-base-200 w-fit max-w-sm text-md">
            <li v-for="item in menuItems" :key="item.id">
                <RouterLink :to="{ name: item.href }" exact-active-class="active" 
                @click="menuItemClick(item.id)">
                    <span class="material-symbols-rounded mx-auto">{{ item.icon }}</span>
                    <p class="font-bold text-lg">{{ item.tooltip }}</p>
                </RouterLink>
                <ul v-if="openButtonId === item.id">
                    <li v-for="child in item.children" :key="child.id">
                        <RouterLink :to="{ name: child.href }" exact-active-class="active"
                        @click="menuItemClick(child.id, item.id)">
                            <span class="material-symbols-rounded mx-auto">{{ child.icon }}</span>
                            <p class="text-lg">{{ child.text }}</p>
                        </RouterLink>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</template>