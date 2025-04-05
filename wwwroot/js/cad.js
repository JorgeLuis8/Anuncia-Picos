window.makePostRequest = async function(user) {
    console.log("Enviando requisição para o servidor...");  // Log para verificar se está chamando a função

    try {
        const response = await fetch("https://api.anunciapicos.shop/auth/cadastro", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        });

        if (response.ok) {
            console.log("Cadastro bem-sucedido!");
            return "success";  // Retorna sucesso se o status for 2xx
        } else {
            console.error("Erro na requisição:", response.status);
            return "error";  // Retorna erro se a resposta não for bem-sucedida
        }
    } catch (error) {
        console.error("Erro ao enviar a requisição:", error);
        return "error";  // Retorna erro caso haja falha na requisição
    }
};
