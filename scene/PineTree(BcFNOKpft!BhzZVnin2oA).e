13
4200478015489
404978072721389 1761863315960588800
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 1.8233747482299805,
    "Y": -11.4586610794067383
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404976569700760:1761863315610383100",
  "next_sibling": "404980503802924:1761863316527033200",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404978073114323:1761863315960679100",
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
  "aoid": "404978073268693:1761863315960715100",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404978073114323:1761863315960679100",
    "DefaultRenderer": "404978073350135:1761863315960734000",
    "DepletedRenderer": "404978073322013:1761863315960727500"
  }
},
{
  "cid": 5,
  "aoid": "404978073290537:1761863315960720100",
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
