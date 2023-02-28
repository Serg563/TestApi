import React from "react";
import axios from "axios";

export default class ClassCompFetchAll extends React.Component {
  constructor() {
    super();
    this.state = {
      Persons: [],
    };
  }

  componentDidMount() {
    axios.get("https://localhost:7024/api/Person").then((response) => {
      this.setState({
        Persons: response.data,
      });
    });
  }

  render() {
    return (
      <section>
        <h1>Products List</h1>
        <div>
          <table>
            <thead>
              <tr>
                <th>Product Id</th>
                <th>Product Name</th>
                <th>Product LastName</th>
                <th>Product Email</th>
              </tr>
            </thead>
            <tbody>
              {this.state.Persons.map((person, index) => {
                return (
                  <tr key={index}>
                    <td>{person.id}</td>
                    <td>{person.first_name}</td>
                    <td>{person.last_name}</td>
                    <td>{person.email}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </section>
    );
  }
}
