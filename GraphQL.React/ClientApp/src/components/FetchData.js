import React, { Component } from 'react';
import { ApolloClient, InMemoryCache } from '@apollo/client';
import { gql } from '@apollo/client';

export class FetchData extends Component {

  constructor(props) {
    super(props);
  }

  componentDidMount() {
    let client = new ApolloClient({
      uri: 'https://localhost:5001/graphql',
      cache: new InMemoryCache()
    });

    client
      .query({
        query: gql`
          query GetProductsWithWorkOrders {
            products
              {
              edges {
                node {
                  productId
                  name
                  listPrice
                  standardCost
                  workOrders
                  {
                    orderQty
                    scrappedQty
                    stockedQty
                  }
                }
                cursor
              }
              pageInfo {
                startCursor
                endCursor
                hasNextPage
                hasPreviousPage
              }
            }
          }
      }).then(result => console.log(result));
  }

  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
      </div>
    );
  }
}
