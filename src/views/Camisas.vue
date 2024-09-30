<script setup>

</script>

<template>
  <main>
    <div class="container">
      <!-- Frase de apresentação -->
      <div class="row mt-4">
        <div class="col-12 text-center">
          <h1 class="presentation">Descubra sua camisa perfeita com estilo e conforto para qualquer ocasião!</h1>
        </div>
      </div>

      <div class="row mt-4">
        <!-- Primeira fileira de camisas -->
        <div class="col-sm-6 col-md-4">
          <div class="card border-0">
            <div class="card-body row">
              <img src="../assets/images/camisa1.png" alt="Camisa 1">
              <p class="price"><b>$20</b></p>
              <p class="description">Camisa Masculina Casual</p>
            </div>
          </div>
        </div>

        <div class="col-sm-6 col-md-4">
          <div class="card border-0">
            <div class="card-body row">
              <img src="../assets/images/camisa3.png" alt="Camisa 2">
              <p class="price"><b>$25.99</b></p>
              <p class="description">Camisa Feminina Treino</p>
            </div>
          </div>
        </div>

        <div class="col-sm-6 col-md-4">
          <div class="card border-0">
            <div class="card-body row">
              <img src="../assets/images/camisa1.png" alt="Camisa 3">
              <p class="price"><b>$39.99</b></p>
              <p class="description">Camisa Masculina Esporte</p>
            </div>
          </div>
        </div>

        <!-- Segunda fileira de camisas -->
        <div class="col-sm-6 col-md-4">
          <div class="card border-0">
            <div class="card-body row">
              <img src="../assets/images/camisa3.png" alt="Camisa 4">
              <p class="price"><b>$29.99</b></p>
              <p class="description">Camisa Feminina Esporte</p>
            </div>
          </div>
        </div>

        <div class="col-sm-6 col-md-4">
          <div class="card border-0">
            <div class="card-body row">
              <img src="../assets/images/camisa1.png" alt="Camisa 5">
              <p class="price"><b>$29.99</b></p>
              <p class="description">Camisa Feminina Treino</p>
            </div>
          </div>
        </div>

        <div class="col-sm-6 col-md-4">
          <div class="card border-0">
            <div class="card-body row">
              <img src="../assets/images/camisa3.png" alt="Camisa 6">
              <p class="price"><b>$29.99</b></p>
              <p class="description">Camisa Masculina Casual</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Jersey+20+Charted&display=swap');
  
  .presentation {
    font-size: 2rem;
    font-weight: bold;
    margin-bottom: 30px;
    color: rgb(6, 50, 107);
  }

  .desconto {
    color: whitesmoke;
    display: flex;
    border-radius: 20px;
    background-color: blue;
    justify-content: center;
  }

  b {
    font-size: x-large;
    color: rgb(6, 50, 107);
  }

  .price {
    font-size: larger;
  }

  .description {
    font-size: medium;
    color: #555;
    text-align: center;
  }

  .card {
    position: relative;
    box-shadow: 0px 1px 13px rgba(0,0,0,0.4);
    cursor: pointer;
    transition: all 120ms;
    display: flex;
    align-items: center;
    justify-content: center;
    background: #fff;
    padding: 0.5em;
    padding-bottom: 3.4em;
    margin-bottom: 100px;
  }

  .card::after {
    content: "Adicionar ao carrinho";
    padding-top: 20px;
    padding-left: 20px;
    position: absolute;
    left: 0;
    bottom: -60px;
    background: #00ca5b;
    color: #fff;
    height: 65px;
    width: 100%;
    transition: all 200ms;
    font-weight: 600;
    text-transform: uppercase;
    opacity: 0;
  }

  .card .title {
    font-family: Arial, Helvetica, sans-serif;
    font-size: 0.9em;
    position: absolute;
    left: 0.625em;
    bottom: 1.875em;
    font-weight: 400;
    color: #000;
  }

  .card .price {
    font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
    font-size: 0.9em;
    position: absolute;
    left: 0.625em;
    bottom: 0.625em;
    color: #000;
  }

  .card:hover::after {
    bottom: 0;
    opacity: 10;
  }

  .card:active {
    transform: scale(0.99);
  }

  .card:active::after {
    content: "Adicionado !";
    height: 3.6em;
  }

  .text {
    max-width: 55px;
  }

</style>