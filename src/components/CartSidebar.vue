<template>
  <div class="cart-sidebar" :class="{ 'is-open': show }">
  <button class="close-btn" @click="handleCartClosed"> 
    <img src="../assets/images/closeIcon.svg" alt="Fechar" height="40px" width="50px">
  </button>
  <center>
    <h3 class="myCart">Meu Carrinho</h3>
  </center>
  <div v-if="cartItems.length">
    <div v-for="(item, index) in cartItems" :key="index" class="cart-item">
      <div>
        <img :src="item.image" alt=""/>
        <h3>{{ item.name }}</h3>
        <p class="price">{{ item.price }}</p>
      </div>
    </div>
  </div>
  <div v-else>
    <p>Seu carrinho está vazio.</p>
  </div>
  <footer>
      <button class="out" @click="handleCartToggle">
        Abandonar carrinho
      </button>
      <button class="buy">
        Finalizar compra
      </button>
  </footer>
</div>

</template>

<script setup>
import { defineProps, defineEmits } from 'vue';

const aparecerRoleta = () => {
mostrarRoleta.value = !mostrarRoleta.value;
};

const handleCartToggle = () => {
  const confirmar = window.confirm("Realmente deseja abandonar o carrinho?");
  if (confirmar){
    emit('update:show', false);
    emit('show-roleta')
    // emit('cart-closed');
    }
};

const handleCartClosed = () => {
  emit('update:show', false);
  emit('cart-closed');
};

const props = defineProps({
show: Boolean,
cartItems: {
  type: Array,
  default: () => []
}
});

const emit = defineEmits(['update:show', 'cart-closed', 'show-roleta']);



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
left: 0px;
background: none;
border: none;
font-size: xx-large;
cursor: pointer;
color: red;
}

.cart-item {
border-top: 1px solid;
display: flex;
align-items: center;
margin-bottom: 20px;
}

.cart-item img {
width: 95px;
height: 95px;
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

.myCart{
  margin-top: 40px;
}

.out {
  width: 250px;
  height: 45px;
  border: 3px solid #ea0606;
  border-radius: 45px;
  transition: all 0.3s;
  cursor: pointer;
  color: #ea0606;
  background: white;
  margin-top: 50px;
  font-size: 1.2em;
  font-weight: 550;
  font-family: sans-serif;
}

.out:hover {
  background: #ea0606;
  color: white;
  font-size: 1.25em;
}

.buy {
  width: 250px;
  height: 45px;
  border: 3px solid #0ba403;
  border-radius: 45px;
  transition: all 0.3s;
  cursor: pointer;
  color: #0ba403;
  background: white;
  margin-top: 5px;
  font-size: 1.2em;
  font-weight: 550;
  font-family: sans-serif;
}

.buy:hover {
  background: #6fc810;
  color: white;
  font-size: 1.25em;
}
</style>