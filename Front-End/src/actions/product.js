import api from './baseUrl'

export const ListProduct = async () => {
    try {
        const response = await api.get(`v1/product/get-all`);
        return response.data

    } catch (err) {
        return err.response.data
    }
}

export const ListProductById = async (productId) => {
    try {
        const response = await api.get(`v1/product/get-by-id/${productId}`);
        return response.data

    } catch (err) {
        return err.response.data
    }
}

export const AddProduct = async (model) => {
    try {
        const response = await api.post(`v1/product/add`, model)
        return response.data

    } catch (err) {
        return err.response.data
    }
}


export const UpdateProduct = async (model) => {
    try {
        const response = await api.put(`v1/product/update`, model);
        return response.data

    } catch (err) {
        return err.response.data
    }
}
export const RemoveProduct = async (productId) => {
    try {
        const response = await api.delete(`v1/product/delete?productId=${productId}`);
        return response.data

    } catch (err) {
        return err.response.data
    }
}