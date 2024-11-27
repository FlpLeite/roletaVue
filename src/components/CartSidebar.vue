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
        <p v-else>Total: <span>{{ formatCurrency(total) }}</span></p>
      </div>
    </div>
    <div v-else>
      <p>Seu carrinho está vazio.</p>
    </div>

    <footer>
      <button class="buy">
        Finalizar compra
      </button>
    </footer>
  </div>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue';

// Recebe as props do componente pai
const props = defineProps({
  show: Boolean,
  cartItems: {
    type: Array,
    default: () => [],
  },
});

// Eventos emitidos pelo componente
const emit = defineEmits(['update:show', 'cart-closed']);

// Variável reativa para armazenar o desconto
const discount = ref(0);

// Função para formatar valores monetários
const formatCurrency = (value) => {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
  }).format(value);
};

// Calcula o subtotal (soma dos preços dos itens no carrinho)
const total = computed(() => {
  return props.cartItems.reduce((acc, item) => {
    const price = parseFloat(item.price);
    return acc + (isNaN(price) ? 0 : price);
  }, 0);
});

// Calcula o total com desconto aplicado
const totalWithDiscount = computed(() => {
  if (discount.value > 0) {
    return total.value - (total.value * (discount.value / 100));
  }
  return total.value;
});

// Fecha o carrinho e emite o evento para o componente pai
const handleCartClosed = () => {
  emit('update:show', false);
  emit('cart-closed');
};

// Função para aplicar o desconto recebido pela roleta
const aplicarDesconto = (valorDesconto) => {
  console.log('Aplicando desconto:', valorDesconto);
  discount.value = valorDesconto;
};

// Listener para receber o evento de desconto da roleta
onMounted(() => {
  window.addEventListener('aplicar-desconto', (event) => {
    aplicarDesconto(event.detail);
  });
});
</script>

<style>
.cart-sidebar {
  position: fixed;
  top: 0;
  right: -300px;
  width: 300px;
  height: 100%;
  background: white;
  box-shadow: -2px 0 5px rgba(0, 0, 0, 0.5);
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
  color: grey;
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

.myCart {
  margin-top: 0px;
  margin-left: 15px;
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
