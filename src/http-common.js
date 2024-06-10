// import axios from 'axios';

// const httpClient = axios.create("http://localhost:1234/api");

// export default httpClient;

import axios from "axios";

export default axios.create({
    baseURL: "https://localhost:7231/",
    headers: {
        "Content-type": "application/json"
    }
});