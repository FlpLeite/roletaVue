<template>
  <div class="cadastro-usuario">
    <h2>Cadastro de Usuário</h2>
    <form @submit.prevent="handleSubmit">
      <div>
        <label for="nome">Nome completo:</label>
        <input
          type="text"
          id="nome"
          v-model="nome"
          required
        />
      </div>
      <div>
        <label for="email">Email:</label>
        <input
          type="email"
          id="email"
          v-model="email"
          required
        />
      </div>
      <div>
        <label for="senha">Senha:</label>
        <input
          type="password"
          id="senha"
          v-model="senha"
          required
        />
      </div>
      <button type="submit" class="btn btn-primary">Cadastrar</button>
    </form>
    <div v-if="mensagemErro" class="mensagem-erro">{{ mensagemErro }}</div>
    <div v-if="mensagemSucesso" class="mensagem-sucesso">{{ mensagemSucesso }}</div>
  </div>
</template>

<script>
import httpCommon from '@/http-common';

export default {
  data() {
    return {
      nome: '',
      email: '',
      senha: '',
      mensagemErro: '',
      mensagemSucesso: ''
    };
  },
  methods: {
    async handleSubmit() {
      this.mensagemErro = '';
      this.mensagemSucesso = '';
      
      const dadosCadastro = {
        nome: this.nome,
        email: this.email,
        senha: this.senha,
      };

      try {
        const resposta = await httpCommon.post('api/Usuario', dadosCadastro);
        if (resposta.status === 201) {
          this.mensagemSucesso = 'Cadastro realizado com sucesso!';
          this.nome = '';
          this.email = '';
          this.senha = '';
        } else {
          this.mensagemErro = 'Erro ao realizar cadastro. Tente novamente.';
        }
      } catch (erro) {
        this.mensagemErro = 'Erro ao realizar cadastro. Tente novamente.';
        console.error('Erro ao enviar dados de cadastro:', erro);
      }
    }
  }
}
</script>

<style scoped>
.cadastro-usuario {
  max-width: 400px;
  margin: 100px auto;
  padding: 30px;
  border: 1px solid #ccc;
  border-radius: 10px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.cadastro-usuario h2 {
  text-align: center;
  margin-bottom: 20px;
}

.cadastro-usuario div {
  margin-bottom: 15px;
}

.cadastro-usuario label {
  display: block;
  margin-bottom: 5px;
}

.cadastro-usuario input {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
}

.cadastro-usuario button {
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