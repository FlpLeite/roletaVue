<script setup>
import { ref } from 'vue';
import camisa1 from '@/assets/images/camisa1.jpeg';
import camisa2 from '@/assets/images/camisa2.jpeg';
import camisa3 from '@/assets/images/camisa3.jpeg';
import camisa4 from '@/assets/images/camisa4.jpeg';
import camisa5 from '@/assets/images/camisa5.jpeg';
import camisa6 from '@/assets/images/camisa6.jpeg';
import camisa7 from '@/assets/images/camisa7.jpeg';

const camisas = ref([
  { id: 1, name: 'Camisa Masculina Casual', price: 20, image: camisa1 },
  { id: 2, name: 'Camisa Feminina Treino', price: 25.99, image: camisa2},
  { id: 3, name: 'Camisa Masculina Esporte', price: 39.99, image: camisa3 },
  { id: 4, name: 'Camisa Feminina Esporte', price: 29.99, image: camisa4 },
  { id: 5, name: 'Camisa Feminina Esporte', price: 29.99, image: camisa5 },
  { id: 6, name: 'Camisa Feminina Esporte', price: 29.99, image: camisa6 },
]);

const formatCurrency = (value) => {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  }).format(value);
};

</script>

<template>
  <main>
    <div class="container">
      <div class="row mt-4">
        <div class="col-12 text-center">
          <h1>Camisas Disponíveis</h1>
        </div>
      </div>
      <div class="row mt-4">
        <div v-for="camisa in camisas" :key="camisa.id" class="col-sm-6 col-md-4">
          <div class="card border-0">
            <div class="card-body row">
              <p class="description">{{ camisa.name }}</p>
              <img :src="camisa.image" :alt="`Imagem de ${camisa.name}`">
              <p class="price"><b>{{ formatCurrency(camisa.price) }}</b></p>
              <button class="add-to-cart-btn" @click="$emit('add-to-cart', camisa)">Adicionar ao carrinho</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<style scoped>
.card {
  position: relative;
  overflow: hidden;
  box-shadow: 0 4px 8px rgba(0.5, 0, 0, 0.4);
  border-radius: 8px;
  transition: box-shadow 0.3s ease;
  margin-bottom: 25px;
}

.add-to-cart-btn {
  position: absolute;
  left: 0;
  bottom: -60px;
  background: #00ca5b;
  color: #fff;
  height: 65px;
  width: 100%;
  font-weight: 600;
  text-transform: uppercase;
  opacity: 0;
  transition: all 200ms;
}

.card:hover .add-to-cart-btn {
  opacity: 1;
  bottom: 0;
}

.card img {
  width: 100%;
  height: auto;
  border-radius: 8px; 
}

.description {
  display: flex;
  margin: 0 auto;
  font-size: 1.4em;
  justify-content: center;
  color: #4a4242;
}

.price {
  font-size: 1.2em;
  color: #333;
}
</style>
