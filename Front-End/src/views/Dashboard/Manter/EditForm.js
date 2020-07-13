import React from 'react';
import PropTypes from 'prop-types';
import clsx from 'clsx';
import * as Yup from 'yup';
import { Formik } from 'formik';
import { useSnackbar } from 'notistack';
import {
    Box,
    Button,
    Card,
    CardContent,
    Grid,
    TextField,
    makeStyles
} from '@material-ui/core';
import { AddProduct, UpdateProduct } from '../../../actions/product'

const useStyles = makeStyles(() => ({
    root: {}
}));

function EditForm({
    className,
    product,
    productId,
    ...rest
}) {
    const classes = useStyles();
    const { enqueueSnackbar } = useSnackbar();

    const handleOnSubmit = (values, actions) => {
        if (!productId) {

            let model = {
                "name": values.name,
                "quantity": values.quantity,
                "unitaryValue": values.unitaryValue,
            }
            AddProduct(model).then(response => {
                if (response.success) {
                    actions.setSubmitting(false);
                    actions.resetForm();
                    enqueueSnackbar('Produto Adicionado com sucesso', {
                        variant: 'success',
                    });
                }
            }).catch(error => {
                actions.setSubmitting(false);
                enqueueSnackbar(error, {
                    variant: 'error',
                });
            })
        } else {
            UpdateProduct(values).then(response => {
                if (response.success) {
                    actions.setSubmitting(false);
                    actions.resetForm();
                    enqueueSnackbar('Produto Atualizado com sucesso', {
                        variant: 'success',
                    });
                }
            }).catch(error => {
                actions.setSubmitting(false);
                enqueueSnackbar(error, {
                    variant: 'error',
                });
            })
        }
    }
    return (
        <Formik
            initialValues={{
                id: product.id || '',
                name: product.name || '',
                quantity: product.quantity || '',
                unitaryValue: product.unitaryValue || '',
            }}
            validationSchema={Yup.object().shape({
                name: Yup.string().required('Nome é Obrigatório'),
                quantity: Yup.string().required('Quantidade é Obrigatório'),
                unitaryValue: Yup.string().required('Valor é Obrigatório'),
            })}
            onSubmit={handleOnSubmit}
        >
            {({
                errors,
                handleBlur,
                handleChange,
                handleSubmit,
                isSubmitting,
                touched,
                values
            }) => (
                    <form
                        className={clsx(classes.root, className)}
                        onSubmit={handleSubmit}
                        {...rest}
                    >

                        <Card>
                            <CardContent>

                                <Grid
                                    container
                                    spacing={3}
                                >
                                    <Grid
                                        item
                                        md={12}
                                        xs={12}
                                    >
                                        <TextField
                                            error={Boolean(touched.name && errors.name)}
                                            fullWidth
                                            helperText={touched.name && errors.name}
                                            label="Nome do Produto"
                                            name="name"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            required
                                            value={values.name}
                                            variant="outlined"
                                        />
                                    </Grid>
                                    <Grid
                                        item
                                        md={12}
                                        xs={12}
                                    >
                                        <TextField
                                            error={Boolean(touched.quantity && errors.quantity)}
                                            fullWidth
                                            helperText={touched.quantity && errors.quantity}
                                            label="Quantidade"
                                            name="quantity"
                                            type="number"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            required
                                            value={values.quantity}
                                            variant="outlined"
                                        />
                                    </Grid>
                                    <Grid
                                        item
                                        md={12}
                                        xs={12}
                                    >
                                        <TextField
                                            error={Boolean(touched.unitaryValue && errors.unitaryValue)}
                                            fullWidth
                                            helperText={touched.phone && errors.unitaryValue}
                                            label="Valor Unitário"
                                            name="unitaryValue"
                                            onBlur={handleBlur}
                                            onChange={handleChange}
                                            value={values.unitaryValue}
                                            variant="outlined"
                                        />
                                    </Grid>
                                </Grid>
                                <Box mt={2}>
                                    <Button
                                        variant="contained"
                                        color="secondary"
                                        type="submit"
                                        disabled={isSubmitting}
                                    >
                                        {productId ? 'Atualizar Produto' : 'Adicionar Produto'}
                                    </Button>
                                </Box>
                            </CardContent>
                        </Card>
                    </form>
                )}
        </Formik>
    );
}

EditForm.propTypes = {
    className: PropTypes.string,
};

export default EditForm;
