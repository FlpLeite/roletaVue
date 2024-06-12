<template>
  <div class="login">
    <h2>Login</h2>
    <form @submit.prevent="login">
      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" id="email" v-model="email" required />
      </div>
      <div class="form-group">
        <label for="password">Senha:</label>
        <input type="password" id="password" v-model="password" required />
      </div>
      <button type="submit" class="btn btn-primary">Entrar</button>
    </form>
    <div v-if="mensagemErro" class="mensagem-erro">{{ mensagemErro }}</div>
    <div v-if="mensagemSucesso" class="mensagem-sucesso">{{ mensagemSucesso }}</div>
  </div>
</template>

<script>
import httpCommon from '@/http-common';
import router from '@/router'

export default {
  data() {
    return {
      email: '',
      senha: '',
      mensagemErro: '',
      mensagemSucesso: '',
    };
  },
  methods: {
    async login() {
      this.mensagemErro = '';
      this.mensagemSucesso = '';
      
      const dadosLogin = {
        email: this.email,
        senha: this.senha,
      };

      try {
        const resposta = await httpCommon.get('api/Usuario', dadosLogin);
        if (resposta.status === 200) {
          this.mensagemSucesso = 'Login realizado com sucesso!';
          this.email = '';
          this.senha = '';

          router.push('/')
        } else {
          this.mensagemErro = 'Erro ao realizar login. Tente novamente.';
        }
      } catch (erro) {
        if (erro.response && erro.response.data && erro.response.data.message) {
          this.mensagemErro = `Erro: ${erro.response.data.message}`;
        } else {
          this.mensagemErro = 'Erro ao realizar login. Tente novamente.';
        }
        console.error('Erro ao enviar dados de login:', erro);
      }
    }
  }
}
</script>

<style scoped>
.login {
  max-width: 400px;
  margin: 100px auto;
  padding: 30px;
  border: 1px solid #ccc;
  border-radius: 10px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.login h2 {
  text-align: center;
  margin-bottom: 20px;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
}

input {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
}

button {
  width: 100%;
  padding: 10px;
}

.mensagem-erro {
  color: red;
  margin-top: 10px;
}

.mensagem-sucesso {
  color: green;
  margin-top: 10px;
}
</style>
