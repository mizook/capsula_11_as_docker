<template>
  <div class="min-h-screen bg-gray-100">
    <Navbar />
    <main class="container mx-auto px-4 py-8">
      <div class="flex justify-between items-center mb-6">
        <h1 class="text-3xl font-bold text-gray-800">Estudiantes</h1>
        <button
          @click="showModal = true"
          class="bg-[#28445c] hover:bg-[#388098] text-white font-semibold py-2 px-4 rounded-lg transition duration-300 ease-in-out flex items-center"
        >
          <PlusIcon class="w-5 h-5 mr-2" />
          Agregar Estudiante
        </button>
      </div>
      <StudentList :students="students" />
    </main>
    <AddStudentModal v-model="showModal" @add-student="addStudent" />
  </div>
</template>

<script setup>
import { onMounted, ref } from "vue";
import { PlusIcon } from "lucide-vue-next";

import { api } from "./services/api";

import Navbar from "./components/Navbar.vue";
import StudentList from "./components/StudentList.vue";
import AddStudentModal from "./components/AddStudentModal.vue";

// const students = ref([
//   {
//     id: 1,
//     name: "Juan Pérez",
//     rut: "12.345.678-9",
//     email: "juan.perez@universidad.cl",
//     enrollmentDate: "2023-03-01",
//   },
//   {
//     id: 2,
//     name: "María González",
//     rut: "98.765.432-1",
//     email: "maria.gonzalez@universidad.cl",
//     enrollmentDate: "2023-03-02",
//   },
// ]);

const students = ref([]);
const showModal = ref(false);

const addStudent = async (newStudent) => {
  try {
    const response = await api.post("api/students", newStudent);

    students.value.push(response.data);
    showModal.value = false;
  } catch (error) {
    console.error("Error al agregar estudiante:", error);
  }
};

onMounted(async () => {
  const res = await api.get("api/students");
  students.value = res.data;
});
</script>
