<script setup>
import {ref} from "vue"
import Roleta from "./components/Roleta.vue"
import CartSidebar from './components/CartSidebar.vue'

let originalTitle = document.title;
let blinkInterval;
let roletaTimeout;

const mostrarRoleta = ref(false);
const mostrarCarrinho = ref(false);


const handleCartClosed = () => {
  mostrarCarrinho.value = false;
  mostrarRoleta.value = false;
};

const handleShowRoleta = () => {
  mostrarCarrinho.value = false;
  mostrarRoleta.value = true;
}

const toggleCart = () => {
  mostrarCarrinho.value = !mostrarCarrinho.value;
};

const cartItems = ref([
  { name: 'Camisa 1', price: '29.99', image: 'src/assets/images/camisa1.png' },
  { name: 'Camisa 2', price: '25.99', image: 'src/assets/images/camisa3.png' },
  { name: 'Camisa 3', price: '39.99', image: 'src/assets/images/camisa1.png' }
]);

document.addEventListener('visibilitychange', function() {
    if (document.hidden) {
        blinkInterval = setInterval(function() {
            document.title = document.title === "Ainda está aí?" ? " ‎  " : "Ainda está aí?";
        }, 1000);
        
        roletaTimeout = setTimeout(() => {
            mostrarRoleta.value = true; 
        }, 300); 
    } else {
        clearInterval(blinkInterval);
        clearTimeout(roletaTimeout); 
        document.title = originalTitle;
    }
});

</script>

<template>
  <nav class="navbar navbar-expand-lg bg-body-tertiary">
    <div class="container-fluid">
      <a class="navbar-brand" href="/">
        <img src="./assets/images/logo.png" height="100px" alt="">
      </a>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <a class="nav-link" aria-current="page" href="/camisas">Camisas</a>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
              Camisas seleções
            </a>
            <ul class="dropdown-menu">
              <li><a class="dropdown-item" href="#">Palmeiras</a></li>
              <li><a class="dropdown-item" href="#">Brasileira</a></li>
            </ul>
          </li>
        </ul>
        <a href='/login'><button type="button" class="button type1" style="margin-right: 10px;">Entrar</button></a>
        <a href='/cadastro'><button type="button" class="button type1">Cadastrar-se</button></a>
        <div class="navbar-brand cart" @click="toggleCart">
          <img src="https://www.svgrepo.com/show/530571/conversation.svg" alt="Logo" width="60" height="60" class="d-inline-block align-text-top">
        </div>
      </div>
    </div>
</nav>
<div class="main">
    <Roleta v-if="mostrarRoleta" v-model:show="mostrarRoleta"></Roleta>
    <CartSidebar 
      v-model:show="mostrarCarrinho"
      :cartItems="cartItems"
      @cart-closed="handleCartClosed"
      @show-roleta="handleShowRoleta"
    />
    <router-view></router-view>
</div>
</template>

<style>
  .navbar.navbar-expand-lg.bg-body-tertiary {
    position: fixed;
    top: 0;
    width: 100%;
    height: 15.8%;
    z-index: 10;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  }
  
  .container-fluid {
    display: flex;
    align-items: flex-start;
  }

  .nav-item{
    font-size: large;
    float: left;
  }


  .footer-inf{
    margin-top: 15px;
  }


  .nav-link{
    float: right;
    margin-right: 10px;
  }

  .navbar-toggler{
    display: flex;
    margin-top: 30px;
    margin-right: 5px;
  }

  .cart{
    margin-left: 60px;
  }

  .button {
  height: 50px;
  width: 120px;
  position: relative;
  background-color: transparent;
  cursor: pointer;
  border: 2px solid #252525;
  overflow: hidden;
  border-radius: 30px;
  color: #333;
  transition: all 0.5s ease-in-out;
}

.btn-txt {
  z-index: 1;
  font-weight: 800;
  letter-spacing: 4px;
}

.type1::after {
  content: "";
  position: absolute;
  left: 0;
  top: 0;
  transition: all 0.8s ease-in-out;
  background-color: #333;
  border-radius: 30px;
  visibility: hidden;
  height: 10px;
  width: 10px;
  z-index: -1;
}

.button:hover {
  box-shadow: 1px 1px 200px #252525;
  color: #ffffff;
  border: 2px solid #ffffff;
}

.type1:hover::after {
  visibility: visible;
  transform: scale(100) translateX(2px);
}

.main {
  padding-top: 120px; 
}

</style>
