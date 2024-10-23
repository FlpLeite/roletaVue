<script setup>
import httpCommon from '@/http-common';
</script>

<template>
  <div v-if="modalVisivel" class="modal-body">
    <div class="mainbox" id="mainbox">
      <div class="box" id="box">
        <div class="box1">
          <span :class="['font', 'span1', { 'secao-destacada': activeSection === 0 }]"><h5>{{ roleta[0].nome }}</h5></span>
          <span :class="['font', 'span2', { 'secao-destacada': activeSection === 1 }]"><h5>{{ roleta[1].nome }}</h5></span>
          <span :class="['font', 'span3', { 'secao-destacada': activeSection === 2 }]"><h5>{{ roleta[2].nome }}</h5></span>
          <span :class="['font', 'span4', { 'secao-destacada': activeSection === 3 }]"><h5>{{ roleta[3].nome }}</h5></span>
          <span :class="['font', 'span5', { 'secao-destacada': activeSection === 4 }]"><h5>{{ roleta[4].nome }}</h5></span>
        </div>
        <div class="box2">
          <span :class="['font', 'span1', { 'secao-destacada': activeSection === 5 }]"><h5>{{ roleta[5].nome }}</h5></span>
          <span :class="['font', 'span2', { 'secao-destacada': activeSection === 6 }]"><h5>{{ roleta[6].nome }}</h5></span>
          <span :class="['font', 'span3', { 'secao-destacada': activeSection === 7 }]"><h5>{{ roleta[7].nome }}</h5></span>
          <span :class="['font', 'span4', { 'secao-destacada': activeSection === 8 }]"><h5>{{ roleta[8].nome }}</h5></span>
          <span :class="['font', 'span5', { 'secao-destacada': activeSection === 9 }]"><h5>{{ roleta[9].nome }}</h5></span>
        </div>
        <button class="spin" @click="girar()":disabled="botaoDisabled">GIRAR</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      botaoDisabled: false,
      modalVisivel: true,
      roleta: [],
      activeSection: null,
    };
  },
  created() {
    httpCommon.get("api/Premios")
      .then((data) => {
        console.log("Dados carregados", { data });
        this.roleta = data.data;
      })
      .catch((error) => {
        console.log("Erro", error);
      });
  },
  methods: {
   girar() {
      console.log("Função girar foi chamada");
      const numSetores = this.roleta.length;
      const premioIndex = Math.floor(Math.random() * numSetores);
      this.iniciarAnimacao(premioIndex);
      this.botaoDisabled = true;
   },

   iniciarAnimacao(premioIndex) {
      let currentIndex = 0;
      const voltasCompletas = 10;
      const tempoTotal = 6000;
      const tempoPorSetor = tempoTotal / (voltasCompletas * this.roleta.length + premioIndex);

      const interval = setInterval(() => {
         this.activeSection = currentIndex;
         currentIndex = (currentIndex + 1) % this.roleta.length;
      }, tempoPorSetor);

      setTimeout(() => {
         clearInterval(interval);
         this.destacarPremio(premioIndex, currentIndex);
      }, tempoTotal);
   },

   destacarPremio(premioIndex, currentIndex) {
      let delay = 10000; 
      const interval = setInterval(() => {
         this.activeSection = currentIndex;
         if (currentIndex === premioIndex) {
         clearInterval(interval);
         setTimeout(() => {
            alert("Você ganhou: " + this.roleta[premioIndex].nome);
            this.resetarRoleta();
            this.fecharModal();
         }, 300);
         } else {
         currentIndex = (currentIndex + 1) % this.roleta.length;
         delay +=100000000
         }
      }, 100);
   },

   resetarRoleta() {
      this.activeSection = null;
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
   margin: 0;
   padding: 0;
}

.secao-destacada {
  position: absolute;
  border: 9px solid #FFD700;
  border-radius: 50%;
  z-index: 1;
  width: 100%;
  height: 100%;
  color: #FFD700;
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

@keyframes pulse {
  0% { transform: scale(1); }
  50% { transform: scale(1.1); }
  100% { transform: scale(1); }
}

.mainbox {
   position: relative;
   width: 650px; 
   height: 650px; 
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
   border: 10px solid rgb(230, 230, 230);
   overflow: hidden;
   transition: all ease-in-out 5s;
   color: rgb(0, 0, 0);
}

.box2 {
   width: 100%;
   height: 100%;
   transform: rotate(180deg);
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
   background-color: #930093;
}

.span4 {
   clip-path: polygon(71% 0, 100% 18%, 50% 50%);
   background-color: #ff2a00;
}

.span5 {
   clip-path: polygon(100% 18%, 100% 50%, 50% 50%);
   background-color: #ff8000;
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
   top: 22%;
   right: 37%;
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
   width: 80px;
   height: 80px;
   border-radius: 50%;
   border: 4px solid #000;
   background: #e51d1d;
   color: #000;
   box-shadow: 0 3px 15px #000;
   font-weight: bold;
   font-size: 18px;
   cursor: pointer;
   z-index: 10000;
}

.spin:active{
   width: 70px;
   height: 70px;
   font-size: 15px;
}

.spin:disabled {
   cursor: not-allowed;
}
</style>
