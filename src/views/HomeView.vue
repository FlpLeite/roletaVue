<script setup>

  
</script>

<template>
  <main>
    <div class="container">
      <div class="row mt-4">
        <div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa1.png" alt="">
              <p class="price"><b>$29.99</b></p>
            </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa3.png" alt="">
              <p class="price"><b>$25.99</b></p>
            </div>
            
          </div>
        </div>
        <div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa1.png" alt="">
              <p class="price"><b>$39.99</b></p>
            </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa3.png" alt="">
              <p class="price"><b>$29.99</b></p>
            </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa3.png" alt="">
              <p class="price"><b>$29.99</b></p>
            </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa1.png" alt="">
              <p class="price"><b>$29.99</b></p>
            </div>
          </div>
        </div>
        <div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa3.png" alt="">
              <p class="price"><b>$29.99</b></p>
            </div>
          </div>
        </div><div class="col-sm-6 col-md-3">
          <div class="card border-0">
            <div class="card-body row">
              <p class="desconto">10% OFF</p>
              <img src="../assets/images/camisa1.png" alt="">
              <p class="price"><b>$29.99</b></p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>


<style>
  @import url('https://fonts.googleapis.com/css2?family=Jersey+20+Charted&display=swap');
  
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
    background: #00AC7C;
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