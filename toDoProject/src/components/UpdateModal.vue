<template>
    <div class="modal is-active" v-if="updateModalVisability">
        <div class="modal-background"></div>
        <div class="modal-card">
          <header class="modal-card-head">
            <p class="modal-card-title">Update your task</p>
            <button class="delete" aria-label="close" @click="toggleModal"></button>
          </header>
          <section class="modal-card-body">
           <p class="modal-body-text">Select the Deadline: <input type="date" v-model="updateData.date" required/> </p>
            <p class="modal-body-text">Task:</p>
            <textarea class="textarea" placeholder="Enter your task here" v-model="updateData.task" required></textarea>
            <p style="color:red" v-if="infoMsgState">{{ infoMsg }}</p>
          </section>
          <footer class="modal-card-foot">
            <button class="button is-success" @click="save">Save changes</button>
            <button class="button" @click="toggleModal">Cancel</button>
          </footer>
        </div>
      </div>
</template>
<script>
import axios from 'axios'
export default {
  props: ['updateData', 'updateModalVisability'],
  data () {
    return {
      selectedDate: undefined,
      taskInput: undefined,
      infoMsgState: false,
      infoMsg: ''
    }
  },
  methods: {
    async save () {
      if (this.selectedDate === undefined) {
        this.infoMsg = 'Please fill select the date!'
        this.infoMsgState = true
      } else if (this.taskInput === undefined) {
        this.infoMsg = 'Please enter your task!'
        this.infoMsgState = true
      } else {
        this.infoMsgState = false
        await axios
          .put(this.$apiUrl + '?id=' + this.updateData.ID + '&task=' + this.updateData.task + '&date=' + this.updateData.date + '&status=' + this.updateData.status)
          .catch((error) => {
            this.errorMessage = error.message
            console.error('ERRORAS!', error)
          })
        await this.$emit('updateData')
        await this.toggleModal()
      }
    },
    toggleModal () {
      this.infoMsgState = false
      this.selectedDate = undefined
      this.taskInput = undefined
      this.$emit('toggleModal')
    }
  }
}
</script>
<style>
.modal-body-text{
    color:#BEB7A4
}
.modal-card-foot{
    background-color: black;
    border-color: #BEB7A4;
}
.modal-card-body{
    background-color: black !important;
}
.modal-card-head{
    background-color: black !important;
    border-color: #BEB7A4;
}
.modal-card-title{
    color: #c19921;
}
</style>
