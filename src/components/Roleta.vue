
<script setup>
import httpCommon from '@/http-common';
  
</script>
<template>
	<div v-if="modalVisivel" class="modal-body">
	  <div class="mainbox" id="mainbox">
		<div class="seta"></div>

		<div class="box" id="box">
		  	<div class="box1">
				<span class="font span1"><h5>{{ roleta[0].nome }}</h5></span>
				<span class="font span2"><h5>{{ roleta[1].nome }}</h5></span>
				<span class="font span3"><h5>{{ roleta[2].nome }}</h5></span>
				<span class="font span4"><h5>{{ roleta[3].nome }}</h5></span>
				<span class="font span5"><h5>{{ roleta[4].nome }}</h5></span>

			</div>
		
			<div class="box2">
				<span class="font span1"><h5>{{ roleta[5].nome }}</h5></span>
				<span class="font span2"><h5>{{ roleta[6].nome }}</h5></span>
				<span class="font span3"><h5>{{ roleta[7].nome }}</h5></span>
				<span class="font span4"><h5>{{ roleta[8].nome }}</h5></span>
				<span class="font span5"><h5>{{ roleta[9].nome }}</h5></span>
			</div>

		  <button class="spin" @click="girar()">Girar</button>
		</div>
	  </div>
	</div>
</template>

<script>
export default {
 data() {
   return {
	 modalVisivel: true,
	 roleta: []
   };
 },
created(){
	httpCommon.get("api/Premios")
			.then((data) => {
				console.log("Dados carregados", {data});
				this.roleta = data.data
			})
			.catch((error) => {
				console.log("Erro", error);
			});
},
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
	   this.fecharModal();
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
   fecharModal() {
	   this.modalVisivel = false;
   }
 },
};
</script>

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
   background-color: #00FF00;
}

.span2 {
   clip-path: polygon(0 17%, 30% 0, 50% 50%);
   background-color: #0000FF;
}

.span3 {
   clip-path: polygon(30% 0, 71% 0, 50% 50%);
   background-color: #800080;
}

.span4 {
   clip-path: polygon(71% 0, 100% 18%, 50% 50%);
   background-color: #FF0000;
}

.span5 {
   clip-path: polygon(100% 18%, 100% 50%, 50% 50%);
   background-color: #FFFF00;
}

/* .box2 .span3 {
   background-color: #18f5d0;
} */

.box2 {
   width: 100%;
   height: 100%;
   transform: rotate(180deg);
} 



.font {
   color: #fff;
   font-size: 20px;
}

.box1 .span1 h5 {
   position: absolute;
   top: 40%;
   right: 63%;
   transform: rotate(198deg);
   text-align: center;
}

.box1 .span2 h5 {
   position: absolute;
   top: 25%;
   right: 56%;
   transform: rotate(-130deg);
   text-align: center;
}

.box1 .span3 h5 {
   position: absolute;
   top: 21%;
   right: 37%;
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
   right: 11%;
   transform: rotate(-15deg);
   text-align: center;
}

.box2 .span1 h5 {
   position: absolute;
   top: 40%;
   right: 64%;
   transform: rotate(197deg);
   text-align: center;
}

.box2 .span2 h5 {
   position: absolute;
   top: 27%;
   right: 54%;
   transform: rotate(-127deg);
   text-align: center;
}

.box2 .span3 h5 {
   position: absolute;
   top: 24%;
   right: 41%;
   transform: rotate(270deg);
   text-align: center;
}

.box2 .span4 h5 {
   position: absolute;
   top: 26%;
   right: 20%;
   transform: rotate(306deg);
   text-align: center;
}

.box2 .span5 h5 {
   position: absolute;
   top: 39%;
   right: 10%;
   transform: rotate(-18deg);
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
