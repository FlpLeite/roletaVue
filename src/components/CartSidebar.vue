<template>
  <div class="cart-sidebar" :class="{ 'is-open': show }">
  <button class="close-btn" @click="handleCartToggle">X</button>
  <h2>Meu Carrinho</h2>
  <div v-if="cartItems.length">
    <div v-for="(item, index) in cartItems" :key="index" class="cart-item">
      <div>
        <img :src="item.image" alt="" />
        <h3>{{ item.name }}</h3>
        <p>{{ item.price }}</p>
      </div>
    </div>
  </div>
  <div v-else>
    <p>Seu carrinho está vazio.</p>
  </div>
</div>
</template>

<script setup>
import { defineProps, defineEmits } from 'vue';

const aparecerRoleta = () => {
mostrarRoleta.value = !mostrarRoleta.value;
};

const props = defineProps({
show: Boolean,
cartItems: {
  type: Array,
  default: () => []
}
});

const emit = defineEmits(['update:show', 'cart-closed']);

const handleCartToggle = () => {
emit('update:show', !props.show);
if (props.show) {
  emit('cart-closed');
}
};

</script>

<style>
.cart-sidebar {
position: fixed;
top: 0;
right: -300px;
width: 300px;
height: 100%;
background: white;
box-shadow: -2px 0 5px rgba(0,0,0,0.5);
transition: right 0.3s ease;
z-index: 1000;
padding: 20px;
overflow-y: auto;
}

.cart-sidebar.is-open {
right: 0;
}

.close-btn {
position: absolute;
top: 10px;
left: 20px;
background: none;
border: none;
font-size: xx-large;
cursor: pointer;
color: red;
}

.cart-item {
display: flex;
align-items: center;
margin-bottom: 20px;
}

.cart-item img {
width: 50px;
height: 50px;
margin-right: 10px;
}

.cart-item h3 {
margin: 0;
}

.cart-sidebar h2 {
padding: 30px;
margin: 0;
}

.cart-item p {
margin: 0;
color: grey;
}
</style>