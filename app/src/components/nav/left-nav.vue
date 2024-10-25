<script setup>
    import { ref } from 'vue'
    const menuItems = ref([
        {id: "0", tooltip: "ByteBite Home", icon: "home", href: "/", text: "", children: []},
        {id: "1", tooltip: "Groceries", icon: "nutrition", href: "/digitalpantry", text: "", children: [
            {id: "5", tooltip: "Photograph Receipt", icon: "photo_camera", text: "Photograph Receipt", href: "/digitalpantry/scan-receipt"},
            {id: "6", tooltip: "Scan Barcodes", icon: "barcode_scanner", text: "Scan Barcodes", href: "/digitalpantry/scan-barcodes"},
            {id: "7", tooltip: "Enter UPCs", icon: "input", text: "Enter UPCs", href: "/digitalpantry/add-groceries"}
        ]},
        {id: "2", tooltip: "Recipes", icon: "menu_book", href: "/reciperecon", text: "", children: []},
        {id: "3", tooltip: "Cook", icon: "skillet", href: "/", text: "", children: []},
        {id: "4", tooltip: "Household", icon: "diversity_4", href: "/", text: "", children: []}
    ])
</script>
<template>
    <ul class="h-screen menu bg-base-200 flex flex-col justify-center">
        <li v-for="item in menuItems" :key="item.id" class="tooltip tooltip-right" :data-tip="item.tooltip">
            <details>
                <summary>
                    <RouterLink :to="item.href" exact-active-class="active" class="flex flex-row gap-1">
                        <span class="material-symbols-rounded mx-auto">{{ item.icon }}</span>
                        <p class="prose prose-sm">{{ item.tooltip }}</p>
                    </RouterLink>
                </summary>
                <ul v-if="item.children.length > 0">
                    <li v-for="child in item.children" :key="child.id">
                        <RouterLink :to="child.href" exact-active-class="active" class=" flex flex-row gap-1">
                            <span class="material-symbols-rounded mx-auto">{{ child.icon }}</span>
                            <p class="prose prose-sm">{{ child.text }}</p>
                        </RouterLink>
                    </li>
                </ul>
            </details>
        </li>
    </ul>
</template>