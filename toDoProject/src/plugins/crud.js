import axios from 'axios'
export const crud = {}

var apiUrl = 'https://localhost:7281/api/ToDoTask'

crud.getData = function () {
  return new Promise((resolve) => {
    axios.get(apiUrl).then((r) => resolve(r.data))
  })
}

crud.updateData = function (data) {
  return axios
    .put(apiUrl + '/' + data.id, data)
    .then(() => {
      const info = {
        message: 'Task was updated!',
        type: 'success'
      }
      return info
    })
    .catch((error) => {
      const info = {
        message: error.response,
        type: 'danger'
      }
      return info
    })
}

crud.addData = function (data) {
  return axios
    .post(apiUrl, data)
    .then(() => {
      const info = {
        message: 'Task was added to your ToDo list!',
        type: 'success'
      }
      return info
    })
    .catch((error) => {
      const info = {
        message: error.response,
        type: 'danger'
      }
      return info
    })
}

crud.deleteData = function (data) {
  return axios
    .delete(apiUrl + '/' + data)
    .then(() => {
      const info = {
        message: 'Deleted successfully!',
        type: 'success'
      }
      return info
    })
    .catch(function (error) {
      const info = {
        message: error.response,
        type: 'danger'
      }
      return info
    })
}

export default {
  install (Vue) {
    Vue.prototype.$crud = crud
  }
}
