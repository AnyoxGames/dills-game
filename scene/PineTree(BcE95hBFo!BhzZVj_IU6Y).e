13
4028679323649
404961620136296 1761863312127119000
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -2.4310941696166992,
    "Y": -9.8124599456787109
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404959689068001:1761863311677178100",
  "next_sibling": "404964696299752:1761863312843868200",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404961620433254:1761863312127187300",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404961620556793:1761863312127216100",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404961620433254:1761863312127187300",
    "DefaultRenderer": "404961620610371:1761863312127228600",
    "DepletedRenderer": "404961620591666:1761863312127224300"
  }
},
{
  "cid": 5,
  "aoid": "404961620571757:1761863312127219600",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
