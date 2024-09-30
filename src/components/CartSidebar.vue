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
          <p class="price">{{ formatCurrency(item.price) }}</p>
        </div>
      </div>

      <div class="cart-total">
        <p>Subtotal: <span>{{ formatCurrency(total) }}</span></p>
        <p v-if="discount > 0">Desconto: <span>{{ discount }}%</span></p>
        <p v-if="discount > 0">Total com desconto: <span>{{ formatCurrency(totalWithDiscount) }}</span></p>
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
import { defineProps, defineEmits, computed } from 'vue';

const props = defineProps({
  show: Boolean,
  cartItems: {
    type: Array,
    default: () => []
  },
  discount: {
    type: Number,
    default: 0
  }
});

const emit = defineEmits(['update:show', 'cart-closed', 'show-roleta']);

const formatCurrency = (value) => {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  }).format(value);
};

const total = computed(() => {
  return props.cartItems.reduce((acc, item) => {
    const price = parseFloat(item.price);
    return acc + (isNaN(price) ? 0 : price);
  }, 0);
});

const totalWithDiscount = computed(() => {
  const subtotal = total.value;
  if (props.discount > 0) {
    return subtotal - (subtotal * (props.discount / 100));
  }
  return subtotal;
});

const handleCartToggle = () => {
  const confirmar = window.confirm("Realmente deseja abandonar o carrinho?");
  if (confirmar) {
    emit('update:show', false);
    emit('show-roleta');
  }
};

const handleCartClosed = () => {
  emit('update:show', false);
  emit('cart-closed');
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
top: 7px;
left: 0px;
background: none;
border: none;
font-size: xx-large;
cursor: pointer;
color: red;
}

.cart-item {
border-top: 1px solid #ddd;
display: flex;
align-items: center;
margin-bottom: 14px;
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
}

.cart-total {
  margin-top: 20px;
  border-top: 1px solid #ddd;
  padding-top: 20px;
  text-align: left;
}


.cart-total p {
  margin: 0;
  font-size: 1.2em;
  font-weight: 500;
}

.myCart{
  margin-top: 0px;
  margin-left: 15px;
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
  margin-top: 20px;
  font-size: 1.2em;
  font-weight: 550;
  font-family: sans-serif;
  z-index: 100;
}

.out:hover {
  background: #ea0606;
  color: white;
  font-size: 1.25em;
  z-index: 100;

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
  margin-top: 7px;
  font-size: 1.2em;
  font-weight: 550;
  font-family: sans-serif;
  z-index: 100;
}

.buy:hover {
  background: #0ba403;
  color: white;
  font-size: 1.25em;
  z-index: 100;
}

footer {
  position: relative;
  z-index: 10;
  padding-bottom: 20px;
}
</style>