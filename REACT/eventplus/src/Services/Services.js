import axios from "axios";

export const eventsResource = '/Evento'
export const myEventsResource = '/Presencas/ListarMinhas'
export const nextEventResource = '/Evento/ListarProximos'
export const eventsTypeResource = '/TiposEvento'
export const institutionResource = '/Instituicao'
export const loginResource = '/Login'

const apiPort = '7118';
const localApiUri = `https://localhost:${apiPort}/api`
const externaApiUri = null;

const api = axios.create({
    baseURL: localApiUri
});

export default api;