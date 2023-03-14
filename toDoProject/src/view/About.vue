<template>
    <div id="top">
        <NavBar/>
        <h1 class="title">About</h1>
        <h1 class="text">A simple CRUD (Create, Read, Update, Delete) web page for a todo
          list allows users to manage their daily tasks by adding, editing, and removing items from a list.
          The page consists of a form to add a new task, a table to display the list of tasks,
          and buttons to edit or delete each item. Users can create a new task by filling out the form and
          clicking the "Add" button. The newly added task will appear in the table. Users can also edit or
          delete existing tasks by clicking the corresponding buttons. Editing a task allows the user to change
          the task description or the estimated time to complete it. Deleting a task removes it from the list.
          The web page also include functionality to mark a task as completed.</h1>
    </div>
</template>

<script>
import NavBar from '../components/NavBar.vue'
export default {
  components: {
    NavBar
  },
  data () {
    return {
    }
  }
}
</script>
<style>
.title{
  text-align:center;
  font-size: 30px;
  color:black
}
.text {
  justify-content: center;
  width: 50%;
  text-align: center;
  margin: 0 auto;
  color:rgb(91, 8, 8)
}
</style>
