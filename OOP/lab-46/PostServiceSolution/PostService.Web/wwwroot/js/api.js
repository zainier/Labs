// Робота з REST API сервісу PostService.

const API_BASE_URL = "http://localhost:8080";

/** Помилка виконання запиту: немає з'єднання (status = 0) або неуспішний код відповіді. */
export class ApiError extends Error {
    constructor(message, status = 0) {
        super(message);
        this.name = "ApiError";
        this.status = status;
    }
}

/** Сервер відхилив дані (HTTP 400 ValidationProblem). fieldErrors: { поле: [повідомлення] }. */
export class ValidationError extends ApiError {
    constructor(fieldErrors) {
        super("Сервер відхилив дані відправлення.", 400);
        this.name = "ValidationError";
        this.fieldErrors = fieldErrors;
    }
}

async function request(path, options = {}) {
    let response;

    try {
        response = await fetch(API_BASE_URL + path, options);
    } catch {
        throw new ApiError("Не вдалося з'єднатися із сервером. Перевірте, чи запущено PostService.");
    }

    if (response.status === 400) {
        const problem = await response.json().catch(() => null);

        if (problem?.errors) {
            throw new ValidationError(problem.errors);
        }

        throw new ApiError("Сервер відхилив дані відправлення як некоректні.", 400);
    }

    if (response.status === 404) {
        throw new ApiError("Відправлення не знайдено. Можливо, його вже видалено.", 404);
    }

    if (!response.ok) {
        throw new ApiError(`Сервер повернув помилку ${response.status}.`, response.status);
    }

    return response.status === 204 ? null : response.json();
}

function jsonRequest(method, body) {
    return {
        method,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body)
    };
}

export const postingApi = {
    getAll: () => request("/postings"),
    getById: (id) => request(`/postings/${id}`),
    create: (posting) => request("/postings", jsonRequest("POST", posting)),
    update: (id, posting) => request(`/postings/${id}`, jsonRequest("PUT", posting)),
    remove: (id) => request(`/postings/${id}`, { method: "DELETE" })
};
