<template>
  <img src="../assets/images/Banner.webp" alt="Banner" class="banner">
  
  <div class="card-products">
    <div class="cards">
      <img src="https://images.tcdn.com.br/files/311840/themes/4611/img/settings/fadrfd.jpg?debd50ed44399ba4e0d38d8599143a5b" alt="Chuteira Infantil" class="product-image">
    </div>

    <div class="cards">
      <img src="https://images.tcdn.com.br/files/311840/themes/4611/img/settings/tenis-infantil.jpg?debd50ed44399ba4e0d38d8599143a5b" alt="Tênis Infantil" class="product-image">
    </div>

    <div class="cards">
      <img src="https://images.tcdn.com.br/files/311840/themes/4611/img/settings/440x210-topo-3.jpg?debd50ed44399ba4e0d38d8599143a5b" alt="Pequeno Fanático" class="product-image">
    </div>
  </div>
</template>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Jersey+20+Charted&display=swap');

  .banner {
    max-width: 100%;
    height: auto;
    margin-bottom: 20px;
  }

  .card-products {
    display: flex;
    justify-content: center;
    gap: 10px;
    margin: 0 10px;
  }

  .card {
    padding: 15px;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    text-align: center;
    width: 32%;
  }

  .product-image {
    max-width: 100%;
    height: auto;
    border-radius: 8px;
  }

</style>
