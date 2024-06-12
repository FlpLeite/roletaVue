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
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: '',
      senha: ''
    }
  },
  methods: {
    handleSubmit() {
      console.log('Email:', this.email);
      console.log('Senha:', this.senha);
      alert('Cadastro realizado com sucesso!');
      
      this.email = '';
      this.senha = '';
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
</style>