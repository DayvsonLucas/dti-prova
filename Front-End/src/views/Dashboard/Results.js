/* eslint-disable max-len */
import React, { useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import PerfectScrollbar from 'react-perfect-scrollbar';
import {
    Box,
    Card,
    Divider,
    IconButton,
    SvgIcon,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    makeStyles
} from '@material-ui/core';
import {
    Edit as EditIcon,
    Trash as TrashIcon,
} from 'react-feather';
import { RemoveProduct } from '../../actions/product'

var formatter = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
});


const useStyles = makeStyles((theme) => ({
    root: {},
    queryField: {
        width: 500
    },
    bulkOperations: {
        position: 'relative'
    },
    bulkActions: {
        paddingLeft: 4,
        paddingRight: 4,
        marginTop: 6,
        position: 'absolute',
        width: '100%',
        zIndex: 2,
        backgroundColor: theme.palette.background.default
    },
    bulkAction: {
        marginLeft: theme.spacing(2)
    },
    avatar: {
        height: 42,
        width: 42,
        marginRight: theme.spacing(1)
    }
}));

function Results({ className, products, getProducts, ...rest }) {
    const classes = useStyles();

    const handleRemove = (productId) => {
        RemoveProduct(productId).then(response => {
            if (response.success === true) {
                alert(response.data)
                getProducts()
            } else {
                alert('Falha ao deletar o produto')
            }
        }).catch(error => {
            alert('Falha ao deletar o produto ' + error)
        })
    }

    return (
        <Card
            className={clsx(classes.root, className)}
            {...rest}
        >
            <Divider />
            <PerfectScrollbar>
                <Box minWidth={700}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>
                                    Nome
                                </TableCell>
                                <TableCell>
                                    Valor
                                </TableCell>
                                <TableCell>
                                    Quantidade
                                </TableCell>
                                <TableCell >
                                    Actions
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {products.map((product) => {
                                return (
                                    <TableRow
                                        hover
                                        key={product.id}
                                    >
                                        <TableCell>
                                            {product.name}
                                        </TableCell>
                                        <TableCell>
                                            {formatter.format(product.unitaryValue)}
                                        </TableCell>
                                        <TableCell>
                                            {product.quantity}
                                        </TableCell>
                                        <TableCell >
                                            <IconButton
                                                component={RouterLink}
                                                to={`/dashboard/manter/${product.id}`}
                                            >
                                                <SvgIcon fontSize="small">
                                                    <EditIcon />
                                                </SvgIcon>
                                            </IconButton>
                                            <IconButton onClick={() => handleRemove(product.id)}>
                                                <SvgIcon fontSize="small">
                                                    <TrashIcon />
                                                </SvgIcon>
                                            </IconButton>
                                        </TableCell>
                                    </TableRow>
                                );
                            })}
                        </TableBody>
                    </Table>
                </Box>
            </PerfectScrollbar>
        </Card>
    );
}

Results.propTypes = {
    className: PropTypes.string,
    products: PropTypes.array
};

Results.defaultProps = {
    products: []
};

export default Results;
