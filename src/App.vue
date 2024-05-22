<script setup>
import {ref} from "vue"
import Roleta from "./components/Roleta.vue"

const mostrarRoleta = ref(false)

const aparecerRoleta = () => {
  mostrarRoleta.value = !mostrarRoleta.value;
};

</script>

<template>
  <nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="">
      <img src="./assets/images/logo.png" height="100px" alt="">
    </a>
    
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Camisas</a>
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
      <form class="d-flex" role="search">
        <input class="form-control me-2" type="search" placeholder="Pesquisar" aria-label="Search">
        <button class="btn btn-outline-success" type="submit">Pesquisar</button>
      </form>

      <div class="navbar-brand cart" @click="aparecerRoleta">
        <img src="https://www.svgrepo.com/show/530571/conversation.svg" alt="Logo" width="60" height="60" class="d-inline-block align-text-top">
      </div>
    </div>
  </div>
</nav>

  <div class="main">
      <Roleta v-if="mostrarRoleta" :show="mostrarRoleta" @update:show="mostrarRoleta = $event"></Roleta>
    <router-view></router-view>
  </div>

  
 
</template>

<style>

  body{
    background-color: whitesmoke(250, 247, 247);
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

</style>