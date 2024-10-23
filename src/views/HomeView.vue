<template>
  <a href="/camisas">
    <img src="../assets/images/banner.png" alt="Banner" class="banner">
  </a>
  <div class="card-products">
    <div class="cards">
      <a href="/camisas">
        <img src="https://images.tcdn.com.br/files/311840/themes/4611/img/settings/fadrfd.jpg?debd50ed44399ba4e0d38d8599143a5b" href='/camisas' alt="Chuteira Infantil" class="product-image">
      </a>
    </div>

    <div class="cards">
      <a href="/camisas">
        <img src="https://images.tcdn.com.br/files/311840/themes/4611/img/settings/tenis-infantil.jpg?debd50ed44399ba4e0d38d8599143a5b" href='/camisas' alt="Tênis Infantil" class="product-image">
      </a>
    </div>

    <div class="cards">
      <a href="/camisas">
        <img src="https://images.tcdn.com.br/files/311840/themes/4611/img/settings/440x210-topo-3.jpg?debd50ed44399ba4e0d38d8599143a5b" href='/camisas' alt="Pequeno Fanático" class="product-image">
      </a>  
      </div>
  </div>
</template>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Jersey+20+Charted&display=swap');

  .banner {
    max-width: 100%;
    height: auto;
    margin-bottom: 10px;
  }

  .card-products {
    display: flex;
    justify-content: center;
    gap: 10px;
    margin: 0 10px;
  }

  .cards {
    padding: 10px;
    border-radius: 10px;
    text-align: center;
    width: 32%;
    overflow: hidden;
  }

  .product-image {
    max-width: 100%;
    height: auto;
    border-radius: 8px;
    transition: transform 0.3s ease;
  }

  .cards:hover .product-image {
    transform: scale(1.03);
  }

</style>
