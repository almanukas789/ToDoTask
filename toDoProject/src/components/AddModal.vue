<template>
    <div class="modal is-active" v-if="isVisible">
        <div class="modal-background"></div>
        <div class="modal-card">
          <header class="modal-card-head">
            <p class="modal-card-title">Add To-Do task</p>
            <button class="delete" aria-label="close" @click="toggleModal"></button>
          </header>
          <section class="modal-card-body">
           <p class="modal-body-text">Select Day: <input type="date" v-model="selectedDate"/> </p>
            <p class="modal-body-text">Task:</p>
            <textarea class="textarea" placeholder="Enter your task here" v-model="taskInput"></textarea>
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
  props: ['isVisible'],
  data () {
    return {
      selectedDate: undefined,
      taskInput: undefined
    }
  },
  methods: {
    save () {
      axios
        .post('https://localhost:7281/todo?task=' + this.taskInput + '&date=' + this.selectedDate)
        .catch((error) => {
          this.errorMessage = error.message
          console.error('ERRORAS!', error)
        })
      this.$emit('updateData')
      this.toggleModal()
    },
    toggleModal () {
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
