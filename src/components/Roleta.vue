<template>
	<b-modal v-model:show="show" title="BootstrapVue">
     <div class="modal-body">
       <div class="mainbox" id="mainbox">
         <div class="seta"></div>
         <div class="box" id="box">
           <div class="box1">
             <span class="font span1"><h5>10% de desconto</h5></span>
             <span class="font span2"><h5>5% de desconto</h5></span>
             <span class="font span3"><h5>15% de desconto</h5></span>
             <span class="font span4"><h5>Chuteira</h5></span>
             <span class="font span5"><h5>10% de desconto</h5></span>
           </div>
           <div class="box2">
             <span class="font span1"><h5>Coringa</h5></span>
             <span class="font span2"><h5>Camisa Palmeiras</h5></span>
             <span class="font span3"><h5>Camisa seleção</h5></span>
             <span class="font span4"><h5>Frete grátis</h5></span>
             <span class="font span5"><h5>2 camisas</h5></span>
           </div>
           <button class="spin" @click="girar()">Girar</button>
         </div>
       </div>
     </div>
	</b-modal> 
</template>

<script>
import { BModal } from 'bootstrap-vue-next';

export default {
  methods: {
    girar() {
      console.log("Função girar foi chamada");
      var box = document.getElementById("box");
      var girarDegrees = Math.floor(Math.random() * 360) + 1800;
      box.style.transition = "all ease-in-out 5s";
      box.style.transform = "rotate(" + girarDegrees + "deg)";

      setTimeout(() => {
        var resultado = this.obterResultado(girarDegrees);
        alert("Você ganhou: " + resultado);
        this.resetarRoleta();
      }, 5500);
    },
    obterResultado(girarDegrees) {
      var numSetores = 5;
      var grausPorSetor = 360 / numSetores;
      var offset = 90;
      var indiceSetor = Math.floor(
        ((girarDegrees + offset) % 360) / grausPorSetor
      );
      var premios = [
        "Parabéns, você ganhou: 10% de desconto",
        "Parabéns, você ganhou: 5% de desconto",
        "Parabéns, você ganhou: 15% de desconto",
        "Parabéns, você ganhou: Chuteira",
        "Parabéns, você ganhou: Coringa",
        "Parabéns, você ganhou: Camisa Palmeiras",
        "Parabéns, você ganhou: Camisa seleção",
        "Parabéns, você ganhou: Frete grátis",
        "Parabéns, você ganhou: 2 camisas",
      ];

      var premiosReorganizados = premios.slice(indiceSetor).concat(premios.slice(0, indiceSetor));

  		return premiosReorganizados[0];
    },
    resetarRoleta() {
      var box = document.getElementById("box");
      box.style.transition = "none";
      box.style.transform = "rotate(90deg)";
    },
  },
};
</script>x

<style>
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&family=Jacquard+12+Charted&display=swap');

* {
	box-sizing: border-box;
	margin: 0;
	padding: 0;
	outline: none;
}

.modal-body {
	background-color: white;
	display: flex;
	justify-content: center;
	align-items: center;
	height: 100vh;
	overflow: hidden;
	background-size: cover;
	background-position: center;
}

.mainbox {
    position: relative;
    width: 650px; 
    height: 650px; 
    margin-top: 50px;
}

.mainbox::after {
	position: absolute;
	content: "";
	width: 100%;
	height: 100%;
	background-size: 5%;
	left: 5%;
	top: 48%;
	transform: rotate(90deg);
}

.box {
    width: 90%; 
    height: 90%; 
    position: relative;
    border-radius: 50%;
    border: 10px solid whitesmoke;
    overflow: hidden;
    transition: all ease-in-out 5s;
    transform: rotate(90deg);
}

span {
	width: 100%;
	height: 100%;
	display: inline-block;
	position: absolute;
}

.span1 {
	clip-path: polygon(0 17%, 0 50%, 50% 50%);
	background-color: #81c4ff;
}

.span2 {
	clip-path: polygon(0 17%, 30% 0, 50% 50%);
	background-color: #16588e;
}

.span3 {
	clip-path: polygon(30% 0, 71% 0, 50% 50%);
	background-color: #000
}

.span4 {
	clip-path: polygon(71% 0, 100% 18%, 50% 50%);
	background-color: #81c4ff;
}

.span5 {
	clip-path: polygon(100% 18%, 100% 50%, 50% 50%);
	background-color: #81c4ff;
}

/* .box2 .span3 {
	background-color: #18f5d0;
} */

.box2 {
	width: 100%;
	height: 100%;
	transform: rotate(180deg);
} 

.box2 .span1 {
	background: #208cea;
}

.font {
	color: #fff;
	font-size: 20px;
}

.box1 .span1 h5 {
	position: absolute;
	top: 40%;
	right: 63%;
	transform: rotate(200deg);
	text-align: center;
}

.box1 .span2 h5 {
	position: absolute;
	top: 25%;
	right: 57%;
	transform: rotate(-130deg);
	text-align: center;
}

.box1 .span3 h5 {
	position: absolute;
	top: 22%;
	right: 38%;
	transform: rotate(-90deg);
	text-align: center;
}	

.box1 .span4 h5 {
	position: absolute;
	top: 25%;
	right: 16%;
	transform: rotate(-45deg);
	text-align: center;
}

.box1 .span5 h5 {
	position: absolute;
	top: 40%;
	right: 6%;
	transform: rotate(-15deg);
	text-align: center;
}

.box2 .span1 h5 {
	font-size: 36px;
	position: absolute;
	top: 34%;
	right: 70%;
	transform: rotate(200deg);
	text-align: center;
}

.box2 .span2 h5 {
	position: absolute;
	top: 28%;
	right: 54%;
	transform: rotate(-130deg);
	text-align: center;
}

.box2 .span3 h5 {
	position: absolute;
	top: 15%;
	right: 40%;
	transform: rotate(270deg);
	text-align: center;
}

.box2 .span4 h5 {
	position: absolute;
	top: 25%;
	right: 15%;
	transform: rotate(310deg);
	text-align: center;
}

.box2 .span5 h5 {
	position: absolute;
	top: 38%;
	right: 6%;
	transform: rotate(-20deg);
	text-align: center;
}

.spin{
	position: absolute;
	top: 50%;
	left: 50%;
	transform: translate(-50%, -50%);
	width: 75px;
	height: 75px;
	border-radius: 50%;
	border: 4px solid white;
	background: #1d76e5;
	color: #fff;
	box-shadow: 0 5px 20px #000;
	font-weight: bold;
	font-size: 22px;
	cursor: pointer;
	z-index: 10000;
}

.spin:active{
	width: 70px;
	height: 70px;
	font-size: 20px;
}

</style>